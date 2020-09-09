﻿function addRowProduct(product) {
    let tblItens = document.getElementById("tblItens");
    let tbody = tblItens.getElementsByTagName('tbody')[0];

    let newRow = tbody.insertRow();

    let cellId = newRow.insertCell(0);
    let idText = document.createTextNode(product.id);
    cellId.appendChild(idText);

    let cellDescription = newRow.insertCell(1);
    let descriptionText = document.createTextNode(product.description);
    cellDescription.appendChild(descriptionText);

    let cellDelete = newRow.insertCell(2);
    let cbSelectProduct = document.createElement('input');
    cbSelectProduct.type = 'checkbox';
    cbSelectProduct.name = 'cbSelectProduct';
    cbSelectProduct.id = 'ptworkinfo' + product.id;
    cbSelectProduct.value = product.id;

    cellDelete.appendChild(cbSelectProduct);
}


function addRowProductSelected(product) {
    let tblItens = document.getElementById("tblItensSelected");
    let tbody = tblItens.getElementsByTagName('tbody')[0];

    let newRow = tbody.insertRow();

    let cellId = newRow.insertCell(0);
    let idText = document.createTextNode(product.id);
    cellId.appendChild(idText);

    let cellDescription = newRow.insertCell(1);
    let descriptionText = document.createTextNode(product.description);
    cellDescription.appendChild(descriptionText);

    let cellAmount = newRow.insertCell(1);
    let amountText = document.createTextNode(product.Amount);
    cellAmount.appendChild(amountText);

    let cellDelete = newRow.insertCell(2);
    let btnDeleteProduct = document.createElement('button');
    btnDeleteProduct.type = 'button';
    btnDeleteProduct.name = 'btnDeleteProduct';
    btnDeleteProduct.id = 'btnDeleteProduct' + product.id;
    btnDeleteProduct.setAttribute("class", "btn btn-primary");
    btnDeleteProduct.innerHTML = "Delete";
    btnDeleteProduct.value = 'Delete';
    btnDeleteProduct.addEventListener('click', deleteRowProductSelected.bind(this, product), false);
    cellDelete.appendChild(btnDeleteProduct);
}



function deleteRowProductSelected(product) {
    let newProductsSelected = createOrder.productsSelected.filter(p => {
        return p.id != product.id;
    });
    createOrder.productsSelected = newProductsSelected;
    clearTblItensSelected();
    updateProductsSelecteds();
}


function clearTblItensSelected() {
    let tblItens = document.getElementById("tblItensSelected");
    let tbody = tblItens.getElementsByTagName('tbody')[0];
    tbody.innerHTML = '';
}

function clearTblItens() {
    let tblItens = document.getElementById("tblItens");
    let tbody = tblItens.getElementsByTagName('tbody')[0];
    tbody.innerHTML = '';
}



function updateProductsSelecteds() {
    clearTblItensSelected();
    createOrder.productsSelected.map(p => {
        addRowProductSelected(p);
    });
}




var createOrder = function () {
    return {
        listProducts: function () {

            clearTblItens();

            const description = JSON.stringify(document.getElementById('txtSearchProduct').value);

            fetch('/order/ListByDescription', {
                method: 'post', // or 'PUT'
                body: description,
                headers: {
                    'Accept': 'application/json; charset=utf-8',
                    'Content-Type': 'application/json;charset=UTF-8'
                }
            })
                .then(res => res.json())
                .then(response => {
                    this.products = response;
                    this.products.map(p => {
                        addRowProduct(p);
                    });
                    //console.log('Success:', JSON.stringify(response))
                })
                .catch(error => {
                    console.error('Error:', error);
                });

        },
        products: [],
        productsSelected: [],
        getProductsSelected: function () {
            //this.productsSelected = [];


            let chkboxName = 'cbSelectProduct';
            let checkboxes = document.getElementsByName(chkboxName);
            for (let i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    this.products.map(product => {
                        if (product.id === parseInt(checkboxes[i].value)) {
                            if (this.productsSelected.length > 0) {
                                this.productsSelected.map(p => {
                                    if (p.id != product.id) {
                                        this.productsSelected.push(product);
                                    }
                                });
                            } else {
                                this.productsSelected.push(product);
                            }
                        }
                    });
                }
            }

            updateProductsSelecteds();
            clearTblItens();
        },
        save: function () {

            const data = JSON.stringify({
                id: 0,
                description: document.getElementById('txtDescription').value,
                createDate: null,
                changeDate: null,
                status: document.getElementById('cbStatus').value,
                itens: this.idsProductsSelected
            });


            //headers: { 'Content-Type': 'application/json' },

            fetch('/order/save', {
                method: 'post', // or 'PUT'
                body: data,
                headers: {
                    'Accept': 'application/json; charset=utf-8',
                    'Content-Type': 'application/json;charset=UTF-8'
                }
            })
                .then(res => res.json())
                .then(response => console.log('Success:', JSON.stringify(response)))
                .catch(error => {
                    console.error('Error:', error);
                });

        }
    }

}();





﻿function addRowProduct(product) {
    let tblItens = document.getElementById("tblItens");

    let newRow = tblItens.insertRow(-1);

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


function updateProductsSelecteds() {
    createOrder.productsSelected.map(p => {
        addRowProductSelected(p);
    });
}




var createOrder = function () {
    return {
        listProducts: function () {
            //here will stay fecht
            this.products.push({ id: 1, description: 'Products 001' });
            this.products.push({ id: 2, description: 'Products 002' });
            this.products.push({ id: 3, description: 'Products 003' });
            this.products.push({ id: 4, description: 'Products 004' });

            this.products.map(p => {
                addRowProduct(p);
            });

        },
        products: [],
        productsSelected: [],
        idsProductsSelected: [],
        getProductsSelected: function () {
            this.productsSelected = [];
            this.idsProductsSelected = [];

            let chkboxName = 'cbSelectProduct';
            let checkboxes = document.getElementsByName(chkboxName);
            for (let i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    this.idsProductsSelected.push(checkboxes[i].value);
                }
            }

            this.products.map(product => {
                this.idsProductsSelected.map(idProduct => {
                    if (product.id === parseInt(idProduct)) {
                        this.productsSelected.push(product);
                    }
                });
            });

            updateProductsSelecteds();
        },
        save: function () {

            var url = 'https://localhost:44304/order/save';
            //var username = 'example';
            //var data = JSON.stringify({ name: "Product 001" });
            const data = JSON.stringify({
                id: 0,
                description: 'order 001',
                createDate: null,
                changeDate: null,
                status: '',
                itens: [1, 2]
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





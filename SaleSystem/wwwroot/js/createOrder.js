var createOrder = function () {
    return {
        listProducts: function () {
            //here will stay fecht
            this.products.push({ id: 1, description: 'Products 001' });
            this.products.push({ id: 1, description: 'Products 002' });
            this.products.push({ id: 1, description: 'Products 003' });
            this.products.push({ id: 1, description: 'Products 004' });

            this.products.map(p => {
                addRow(p);
            });
           
        },
        products: [],
        productsSelected: [],
        idsProductsSelected: [],
        getProductsSelected: function () {

            let chkboxName = 'cbSelectProduct';
            let checkboxes = document.getElementsByName(chkboxName);
            for (let i = 0; i < checkboxes.length; i++) {
                // And stick the checked ones onto an array...
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


            console.log(this.productsSelected);

        }
    }

    function addRow(product) {
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

} ();
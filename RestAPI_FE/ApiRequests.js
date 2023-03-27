// Make a PUT request to the endpoint with the customer data
const url = 'https://localhost:7201/customer'
function Update(customerId) {
    fetch(`${url}/edit/${customerId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(customerData)
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            }
            throw new Error('Network response was not ok.');
        })
        .then(data => {
            console.log('Customer updated:', data);
        })
        .catch(error => {
            console.error('Error updating customer:', error);
        });
}

function GetById(id) {
    fetch(`${url}/getbyid/${id}`)
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(error => console.error(error));
}


function GetAll() {
    fetch(`${url}/getall`)
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(error => console.error(error));
}


function Create(customer) {

    fetch(`${url}/create`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(customer)
    })
        .then(response => response.json())
        .then(data => console.log(data))
        .catch(error => console.error(error));
}

function Delete(id) {
    fetch(`${url}/delete/${customerId}`, {
        method: 'DELETE'
    })
        .then(response => {
            if (response.ok) {
                console.log('Customer deleted successfully');
            } else {
                console.error('Failed to delete customer');
            }
        })
        .catch(error => console.error(error));

}
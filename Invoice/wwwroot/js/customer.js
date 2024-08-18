const apiBaseUrl = '/api/customer';

// Fetch all customers
async function fetchAllCustomers() {
    try {
        const response = await fetch(apiBaseUrl);
        return await response.json();
    } catch (error) {
        console.error('Error fetching customers:', error);
    }
}

// Fetch customers based on query
async function fetchCustomers(query) {
    try {
        const response = await fetch(`${apiBaseUrl}/search/?term=${encodeURIComponent(query)}`);
        return await response.json();
    } catch (error) {
        console.error('Error fetching customers:', error);
    }
}

// Create a new customer
async function createCustomer(customer) {
    try {
        const response = await fetch(apiBaseUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(customer)
        });
        return await response.json();
    } catch (error) {
        console.error('Error creating customer:', error);
    }
}
$('#saveCustomerBtn').click(async function () {
    const newCustomer = {
        contactName: $('#contactName').val(),
        email: $('#email').val(),
        billingLine: $('#billingLine').val(),
        billingCity: $('#billingCity').val(),
        billingRegion: $('#billingRegion').val(),
        billingPostalCode: $('#billingPostalCode').val(),
        billingCountry: $('#billingCountry').val(),
        deliveryLine: $('#deliveryLine').val(),
        deliveryCity: $('#deliveryCity').val(),
        deliveryRegion: $('#deliveryRegion').val(),
        deliveryPostalCode: $('#deliveryPostalCode').val(),
        deliveryCountry: $('#deliveryCountry').val()
    };

    const savedCustomer = await createCustomer(newCustomer);
    $('#CustomerId').val(savedCustomer.contactName);
    const $autocompleteInput = $('#autocompleteInput');
    $autocompleteInput.val(savedCustomer.contactName);
    $('#CustomerHiddenId').val(savedCustomer.id);
    $('#customerModal').modal('hide');
});

// Function to update a customer (if needed)
async function updateCustomer(id, updatedData) {
    try {
        const response = await fetch(`${apiBaseUrl}/${id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedData)
        });
        if (response.status === 204) {
            console.log('Customer updated successfully');
        } else {
            const data = await response.json();
            console.log('Update failed:', JSON.stringify(data, null, 2));
        }
    } catch (error) {
        console.error('Error updating customer:', error);
    }
}

// Function to delete a customer (if needed)
async function deleteCustomer(id) {
    try {
        const response = await fetch(`${apiBaseUrl}/${id}`, {
            method: 'DELETE'
        });
        if (response.status === 204) {
            console.log('Customer deleted successfully');
        } else {
            const data = await response.json();
            console.log('Delete failed:', JSON.stringify(data, null, 2));
        }
    } catch (error) {
        console.error('Error deleting customer:', error);
    }
}
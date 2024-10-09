

var CompanyData = [];
$("#CompanyN").focusout(function () {
    var company = document.getElementById('CompanyN').value;
    if (company == "" || company == undefined) {
        return;
    } else {
        var data = { 'name': company };
        data = JSON.stringify(data);
        $.ajax({
            url: "/ManageContact/ValidateCompanyName",
            data: data,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                console.log("check")
                var name = result.CompanyName;
                if (name != null) {
                    if (company.toLowerCase() == name.toLowerCase()) {
                        $("#saveCustomer").attr('disabled', true);
                        $('#Duplicate').show();
                    }
                } else {
                    $("#saveCustomer").attr('disabled', false);
                    $('#Duplicate').hide();
                }

            },
            error: function (error) {
                alert(error.responseText);
            }
        });
    }

});

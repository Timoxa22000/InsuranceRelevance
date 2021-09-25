$(document).ready(function () {
    $(document).on('change', '#TypeStatus', function () {
        if ($(this).val() === '0') {
            $('.InputBIK').show();
            $('.InputLicenseNumber').hide();
        } else {
            $('.InputBIK').hide();
            $('.InputLicenseNumber').show();
        }
    });
    function regiterFormStart() {
        $('.InputLicenseNumber').hide();
    };
    regiterFormStart();

    $(document).on('click', '#loadBankContractInfo', function (e) {
        e.preventDefault();        
        $.ajax({
            url: '/Home/LoadBankContractInfo',
            type: 'POST',
            data: {
                'numberContract': $('#GetInfoContract').val()
            },
            success: function (data) {
                $('#ContractInfo').empty();
                $('#ContractInfo').append(data);
            },
            error: function () {
                console.log('Ошибка во время отправки данных', this);
            }
        });
    });
    $(document).on('click', '#loadInsuranceInfo', function (e) {
        e.preventDefault();
        $.ajax({
            url: '/Home/InsuranceInfo',
            type: 'POST',
            data: {
                'numberContract': $('#GetInfoInsurance').val()
            },
            success: function (data) {
                $('#InsuranceInfo').empty();
                $('#InsuranceInfo').append(data);
            },
            error: function () {
                console.log('Ошибка во время отправки данных', this);
            }
        });
    });
});
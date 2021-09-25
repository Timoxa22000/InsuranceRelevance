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
});
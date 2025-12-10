$(function () {

    $('#registerForm').on('submit', function (e) {

        let isValid = true;

        $('span.text-danger').text('');
        $('#errorMessage').text('');
        $('#successMessage').text('');

        let firstName = $('#firstName').val().trim();
        let lastName = $('#lastName').val().trim();
        let email = $('#email').val().trim();
        let password = $('#password').val();
        let confirmPassword = $('#confirmPassword').val();
        let phone = $('#phone').val().trim();
        let agreeToTerms = $('#agreeToTerms').is(':checked');

        let emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        let phoneRegex = /^[0-9]{9,12}$/;
        const passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&^#()_+\-={}[\]|:;"'<>,./~`]).{7,}$/;

        // Validation
        if (!firstName) {
            $('#firstNameError').text('Vui lòng nhập họ');
            isValid = false;
        }
        if (!lastName) {
            $('#lastNameError').text('Vui lòng nhập tên');
            isValid = false;
        }

        if (!email) {
            $('#emailError').text('Vui lòng nhập email');
            isValid = false;
        } else if (!emailRegex.test(email)) {
            $('#emailError').text('Email không hợp lệ');
            isValid = false;
        }

        if (!password) {
            $('#passwordError').text('Vui lòng nhập mật khẩu');
            isValid = false;
        }
        else if (!passwordRegex.test(password)) {
            $('#passwordError').text('Mật khẩu phải trên 6 ký tự, có ít nhất 1 chữ hoa, 1 chữ thường, 1 số và 1 ký tự đặc biệt.');
            isValid = false;
        }


        if (!confirmPassword) {
            $('#confirmPasswordError').text('Vui lòng nhập xác nhận mật khẩu');
            isValid = false;
        } else if (password !== confirmPassword) {
            $('#confirmPasswordError').text('Mật khẩu nhập lại không trùng');
            isValid = false;
        }

        if (phone && !phoneRegex.test(phone)) {
            $('#phoneError').text('Số điện thoại không hợp lệ');
            isValid = false;
        } else if (!phone) {
            $('#phoneError').text('Vui lòng nhập số điện thoại!');
            isValid = false;
        }

        if (!agreeToTerms) {
            $('#agreeToTermsError').text('Bạn phải đồng ý điều khoản');
            isValid = false;
        }

        if (!isValid) {
            e.preventDefault();
            $("#errorMessage").text("Vui lòng kiểm tra thông tin.");
            return false;
        }

        $('#registerBtnText').addClass('d-none');
        $('#registerBtnSpinner').removeClass('d-none');
        $('#registerBtn').prop('disabled', true);
    });
});

$('#password').on('input', function () {
    $('#passwordError').text('');
    $('#confirmPasswordError').text('');
    let val = $(this).val();
    let strength = $('#passwordStrength');

    if (val.length < 6)
        strength.text('Mật khẩu yếu').css('color', 'red');
    else if (val.length < 10)
        strength.text('Mật khẩu trung bình').css('color', 'orange');
    else
        strength.text('Mật khẩu mạnh').css('color', 'green');
});

$('#confirmPassword').on('input', function () {
    if ($(this).val() !== $('#password').val()) {
        $('#confirmPasswordError').text('Mật khẩu nhập lại chưa trùng');
    } else {
        $('#confirmPasswordError').text('');
    }
});

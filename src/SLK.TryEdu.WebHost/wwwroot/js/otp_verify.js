let timeLeft = 0;
let timerInterval = null;

$(document).ready(function () {
    $('#otpInput').focus();
    loadTimer();

    // Auto-submit when 6 digits entered
    $('#otpInput').on('input', function () {
        const value = $(this).val().replace(/\D/g, '');
        $(this).val(value);

        if (value.length === 6) {
            verifyOtp();
        }
    });

    // Form submit
    $('#otpForm').on('submit', function (e) {
        e.preventDefault();
        verifyOtp();
    });

    // Resend OTP
    $('#resendBtn').on('click', function () {
        resendOtp();
    });
});

function loadTimer() {
    $.get('/verifyemail?handler=OtpTimeLeft')
        .done(function (response) {
            if (response.success) {
                timeLeft = response.timeLeft;
                startTimer();
            } else {
                showAlert('warning', 'OTP đã hết hạn');
                $('#resendBtn').prop('disabled', false);
            }
        })
        .fail(function () {
            showAlert('danger', 'Không thể tải thông tin OTP');
        });
}

function startTimer() {
    if (timerInterval) clearInterval(timerInterval);

    updateTimerDisplay();

    timerInterval = setInterval(function () {
        timeLeft--;
        updateTimerDisplay();

        if (timeLeft <= 0) {
            clearInterval(timerInterval);
            $('#resendBtn').prop('disabled', false);
            showAlert('warning', 'Mã OTP đã hết hạn');
        }
    }, 1000);
}

function updateTimerDisplay() {
    const minutes = Math.floor(timeLeft / 60);
    const seconds = timeLeft % 60;
    const timeString = `${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;

    if (timeLeft > 0) {
        $('#timerDisplay').removeClass('bg-warning bg-danger').addClass('bg-success').text(`Còn lại: ${timeString}`);
    } else {
        $('#timerDisplay').removeClass('bg-success bg-warning').addClass('bg-danger').text('Đã hết hạn');
    }
}

function verifyOtp() {
    const otp = $('#otpInput').val();
    if (otp.length !== 6) {
        showAlert('warning', 'Vui lòng nhập đủ 6 số OTP');
        return;
    }

    $('#verifyBtn').prop('disabled', true).html('<i class="fas fa-spinner fa-spin me-2"></i>Đang xác thực...');

    $.post('/verifyemail?handler=VerifyOtp', {
        __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val(),
        OtpRequest: { Otp: otp }
    })
        .done(function (response) {
            if (response.success) {
                showAlert('success', response.message);
                setTimeout(() => {
                    window.location.href = '/login';
                }, 2000);
            } else {
                showAlert('danger', response.message);
            }
        })
        .fail(function () {
            showAlert('danger', 'Có lỗi xảy ra khi xác thực');
        })
        .always(function () {
            $('#verifyBtn').prop('disabled', false).html('<i class="fas fa-check me-2"></i>Xác thực');
        });
}

function resendOtp() {
    $('#resendBtn').prop('disabled', true).html('<i class="fas fa-spinner fa-spin me-2"></i>Đang gửi...');

    $.post('/verifyemail?handler=ResendOtp', {
        __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
    })
        .done(function (response) {
            if (response.success) {
                showAlert('success', response.message);
                $('#otpInput').val('').focus();
                loadTimer();
            } else {
                showAlert('danger', response.message);
            }
        })
        .fail(function () {
            showAlert('danger', 'Có lỗi xảy ra khi gửi lại OTP');
        })
        .always(function () {
            $('#resendBtn').prop('disabled', false).html('<i class="fas fa-redo me-2"></i>Gửi lại mã OTP');
        });
}

function showAlert(type, message) {
    const alertHtml = `
                <div class="alert alert-${type} alert-dismissible fade show" role="alert">
                    <i class="fas fa-${type === 'success' ? 'check-circle' : type === 'warning' ? 'exclamation-triangle' : 'exclamation-circle'} me-2"></i>
                    ${message}
                    <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
                </div>
            `;
    $('#alertContainer').html(alertHtml);
}
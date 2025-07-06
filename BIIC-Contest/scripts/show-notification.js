function showErrorNotification(message) {
    Swal.fire({
        icon: "error",
        title: "Có lỗi xảy ra!",
        text: `${message}`,
        showDenyButton: true,
        denyButtonText: 'Đóng',
        allowOutsideClick: false,
        showConfirmButton: false,
    });
}

function showSuccessContactNotification(message) {
    Swal.fire({
        icon: "success",
        title: "Thành công!",
        text: `${message}`,
        allowOutsideClick: false,
        showConfirmButton: true,
        confirmButtonText: 'Đóng',
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.reload()
        }
    });
}

function showSuccessLoginNotification(message, callback, timeout) {
    Swal.fire({
        icon: 'success',
        title: 'Thành công',
        text: message,
        timer: timeout || 2000,
        showConfirmButton: false,
        willClose: callback
    });
}

function showSuccessRegisterNotification(message) {
    Swal.fire({
        icon: 'success',
        title: 'Thành công',
        text: message,
        confirmButtonText: 'Đóng',
        allowOutsideClick: false,
        showConfirmButton: true
    }).then((rs) => {
        if (rs.isConfirmed) {
            window.location.reload()
        }
    });
}
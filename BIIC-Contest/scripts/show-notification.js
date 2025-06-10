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

function showSuccessNotification(message) {
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

function showSuccessNotification(message, callback, timeout) {
    Swal.fire({
        icon: 'success',
        title: 'Thành công',
        text: message,
        timer: timeout || 2000,
        showConfirmButton: false,
        willClose: callback
    });
}
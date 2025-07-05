$(document).ready(function () {
    // --- KHAI BÁO BIẾN ---
    let addressData = [];
    const provincesSelect = $('#provinces-select');
    const wardsSelect = $('#wards-select');
    const wardHelperText = $('#ward-helper-text');

    // --- KHỞI TẠO SELECT2 ---
    function initializeSelect2(selector, placeholder) {
        selector.select2({
            theme: 'bootstrap-5',
            placeholder: placeholder,
            allowClear: true
        });
    }

    initializeSelect2(provincesSelect, '-- Chọn tỉnh/thành phố --');
    initializeSelect2(wardsSelect, '-- Chọn phường/xã --');

    // --- TẢI DỮ LIỆU TỪ FILE JSON LOCAL ---
    // SỬA LỖI Ở ĐÂY: Dùng biến đã được tạo từ file .cshtml
    fetch(addressDataUrl)
        .then(response => {
            if (!response.ok) {
                throw new Error('Không tìm thấy file data.json. Kiểm tra lại đường dẫn!');
            }
            return response.json();
        })
        .then(data => {
            console.log("Dữ liệu đã được xử lý:", data);
            addressData = data;
            populateProvinces();
            updateStatistics();
        })
        .catch(error => console.error(error));

    // --- CÁC HÀM XỬ LÝ ---
    function populateProvinces() {
        provincesSelect.empty().append('<option value=""></option>');
        addressData.forEach(province => {
            const option = new Option(province.name, province.province_code, false, false);
            provincesSelect.append(option);
        });
        provincesSelect.trigger('change');
    }

    function updateStatistics() {
        let wardCount = 0;
        addressData.forEach(p => {
            if (p.wards) {
                wardCount += p.wards.length;
            }
        });

        $('#provinces-count').text(addressData.length);
        $('#districts-count').text(0);
        $('#wards-count').text(wardCount);
    }

    function resetForm() {
        provincesSelect.val(null).trigger('change');
    }

    // --- CẬP NHẬT SỰ KIỆN LOGIC ---
    provincesSelect.on('change', function () {
        console.log("1. Sự kiện 'change' trên Tỉnh/Thành phố đã được kích hoạt!")
        const provinceCode = $(this).val();
        console.log("2. Mã tỉnh được chọn (provinceCode):", provinceCode);
        wardsSelect.empty().append('<option value=""></option>').prop('disabled', true);
        wardHelperText.hide();

        if (provinceCode) {
            const selectedProvince = addressData.find(p => p.province_code === provinceCode);
            console.log("3. Đối tượng tỉnh tìm thấy (selectedProvince):", selectedProvince);
            if (selectedProvince && selectedProvince.wards) {
                console.log("4. Danh sách phường/xã tìm thấy:", selectedProvince.wards);
                selectedProvince.wards.forEach(ward => {
                    const option = new Option(ward.name, ward.ward_code, false, false);
                    wardsSelect.append(option);
                });
                wardsSelect.prop('disabled', false);
            }
        } else {
            wardHelperText.show();
        }
        wardsSelect.trigger('change');
    });

    $('#reset-btn').on('click', function () {
        resetForm();
    });
});
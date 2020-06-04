
const _token = document.querySelector('input[name="__RequestVerificationToken"]').value;
//const _token = $('input[name = "__RequestVerificationToken"]').val();

const ajaxHelper = (url,method, data = {}) => {
    return $.ajax({
        url: url,
        method: method,
        dataType: 'json',
        data: data,
        headers: {
            "XSRF-TOKEN": _token
        }
    });
}

export default ajaxHelper;
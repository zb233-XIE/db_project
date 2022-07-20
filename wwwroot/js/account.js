
function checkValid() {
	passWordForm = $("#pw1").val();
	if (passWordForm.length < 6 || passWordForm.length > 10) {
		$("#pw1").removeClass("form-control is-valid");
		$("#pw1").addClass("form-control is-invalid");
		return false;
	}
	else {
		$("#pw1").removeClass("form-control is-invalid");
		$("#pw1").addClass("form-control is-valid");
		return true;
	}
}

function checkSame() {
	if ($("#pw1").val() != $("#pw2").val()) {
		$("#pw2").removeClass("form-control is-valid");
		$("#pw2").addClass("form-control is-invalid");
		return false;
	}
	else {
		$("#pw2").removeClass("form-control is-invalid");
		$("#pw2").addClass("form-control is-valid");
		return true;
	}
}



function login() {
	$.ajax({
		type: "post",
		url: "/Account/login",
		async: false,
		contentType: "application/json",
		dataType: "json",
		data: JSON.stringify({ username: $("#username").val(), password: $("#pw1").val() }),
		success: function (data) {
			alert(data)
		}
	});
}

function register() {
	$.ajax({
		type:"post",
		url: "/Account/register",
		async: false,
		contentType: "application/json",
		dataType: "json",
		data: JSON.stringify({ username: $("#username").val() }),
		success: function (data) {
			alert(data);
			console.log(data)
		}
	});
}
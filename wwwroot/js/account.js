
function login() {
	if ($("input[name='select']:checked").val() == "buyer") {
		$.ajax({
			type: "post",
			url: "/Entry/BuyerLogInForm",
			async: false,
			contentType: "application/json",
			dataType: "json",
			data: JSON.stringify({ BuyerID: $("#phone").val(), Buyername: $("#username").val(), password: $("#pw1").val(), Mail: $("#email"), Birthday: Date() }),
			success: function (data) {
				var jsonData = eval("(" + data + ")");
				if (jsonData.STATUS) {
					window.location.href = "/Entry/Register";
				}
				else {
					alert(jsonData.REASON);
				}
			}
		});
	}
	else {
		$.ajax({
			type: "post",
			url: "/Entry/PublisherLogInForm",
			async: false,
			contentType: "application/json",
			dataType: "json",
			data: JSON.stringify({ PublisherID: $("#phone").val(), Publishername: $("#username").val(), password: $("#pw1").val(), Mail: $("#email"), Birthday: Date() }),
			success: function (data) {
				var jsonData = eval("(" + data + ")");
				if (jsonData.STATUS) {
					window.location.href = "/Entry/Register";
				}
				else {
					alert(jsonData.REASON);
				}
			}
		});
	}
}

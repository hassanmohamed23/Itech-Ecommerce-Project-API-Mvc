//console.log();//https://localhost:44371/Accounts/login
$(".SignUp").click(function () {

	//console.log($(".SignUp"));
	//console.log("you click in sign up");
	//console.log($("#UserNameup").val());
	//console.log($("#Passwordup").val());
	//console.log($("#rePasswordup").val());
	//console.log($("#Emailup").val());
	//var url = "@Url.Action('register','Accounts')"
	//var model = {
	//	UserName: $("#UserNameup").val(), Password: $("#Passwordup").val(),
	//	Emailup: $("#Emailup").val()
	//};
	//$.post(url, model, function (res) {
	//	//$("#SomeDivToShowTheResult").html(res);
	//	console.log("success" + res);
	//});
	//LastName   FistName
	var formData = new FormData();
	formData.append("UserName", $("#UserNameup").val());
	formData.append("Password", $("#Passwordup").val());
	formData.append("Email", $("#Emailup").val());
	formData.append("FistName", $("#FistName").val());
	formData.append("LastName", $("#LastName").val());
	//formData.append("Gender", $("#Gender").val());
	//formData.append("City", $("#City").val());
	$.ajax({
		type: 'POST',
		url: "/Accounts/register", 
		cache: false,
		contentType: false,
		processData: false,
		data: formData,
		success: function (response) {
			alert(response);
		}
	});

});
$(".SignIn").click(function () {
	//console.log($(".SignIn"));
	//console.log("you click in sign in");
	//console.log($("#UserNamein").val());
	//console.log($("#Passwordin").val());
	//console.log($("#checkin").val());
	//var valdata = $("#SignIndata").serialize();
	//var url = "@Url.Action('Login','Accounts')";
	//var model = { UserName: $("#UserNamein").val(), Password: $("#Passwordin").val() };//   ,check:$("#checkin").val()}; 
	//  $.post(url, model, function (res) {
	//	//$("#SomeDivToShowTheResult").html(res);
	//	console.log("success" + res);
	//}); 

	//$.ajax({
	//	type: "POST",
	//	url: "/Accounts/Loginform",
	//	dataType: 'json',
	//	contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
	//	data: valdata
	//});

	var formData = new FormData();
	formData.append("UserName", $("#UserNamein").val());
	formData.append("Password", $("#Passwordin").val());
	//formData.append("Gender", $("#Gender").val());
	//formData.append("City", $("#City").val());
	$.ajax({
		type: 'POST',
		url: "/Accounts/Loginuser", 
		cache: false,
		contentType: false,
		processData: false,
		data: formData,
		success: function (response) {
			alert(response);
		}
	});

});
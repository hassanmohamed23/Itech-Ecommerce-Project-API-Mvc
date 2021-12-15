let fileupload = document.querySelectorAll('.fileupload');
//uploadImages.forEach((fileupload, index) => {
    fileupload[0].addEventListener('change', () => {
        console.log(fileupload); // print the input tag
        var element = fileupload;
        var formData = new FormData();
        var totalFiles = element.files.length;
        console.log(totalFiles);
        for (var i = 0; i < totalFiles; i++) {
            var file = element.files[i];
        }
        formData.append("file", file); 
        $.ajax({
            type: 'POST',  
            url: '/UploadImg/UploadadminImg', 
            data: formData,
            contentType: false, // Not to set any content header  
            processData: false // Not to process data 
        })
            .done(function (response) {
                //console.log(response); 
                if (response.success) {  
                    let label = document.querySelector(`label[for=${fileupload.id}]`);
                     label.style.backgroundImage = `url(${response.imgazureurl})`;//////////////////////////////////for azure storage
                    $('#' + fileupload.id).removeAttr("type");  
                     document.getElementById(fileupload.id).value = `${response.imgazureurl}`; 
                    let productImage = document.querySelector('.product-image'); //////////////////forlocalstorage
                    productImage.style.backgroundImage = `url(${response.imgazureurl})`; 
                    $(".product-image").css("background-size", "contain");
                    $(".product-image").css("border", "1px solid red"); 
                }
            })
            .fail(function (XMLHttpRequest, textStatus, errorThrown) {
                alert("FAIL");
            });
    });
 


// upload image handle
let uploadImages = document.querySelectorAll('.fileupload'); // load all imgs  tag input file
//let imagePaths = []; // will store all uploaded images paths;
//const imagePaths = Array.from({ length: 4 }).map(el => "");
uploadImages.forEach((fileupload, index) => {
    fileupload.addEventListener('change', () => {
            console.log(fileupload); // print the input tag
            var element = fileupload;
            var formData = new FormData();
            var totalFiles = element.files.length;
            console.log(totalFiles);
            for (var i = 0; i < totalFiles; i++) {
                var file = element.files[i]; 
             }
        formData.append("file", file);
               //var files = fileupload.prop("files");
               // var url = "/UploadImg/OnPostMyUploader?handler=MyUploader";
               // formData = new FormData();
               // formData.append("MyUploader", files[0]); 
            //console.log(formData.get("Photo"));
            $.ajax({
                type: 'POST',
                //url: '@Url.Action("UploadImagefun", "UploadImg")',  OnPostMyUploader
                //url: '/UploadImg/UploadImagefun',  
                url: '/UploadImg/UploadLogo',    
                //dataType:"json",  //contentType: "application/json; charset=utf-8",
                data: formData,
                contentType: false, // Not to set any content header  
                processData: false // Not to process data 
            })
            .done(function (response) {
                //console.log(response); 
                if (response.success) {  //////////////////////////////////////////////////////imgazureurl
                    //$("#ImageURL").val(response.ImageURL);
                    //$("#productImage").attr("src", response.ImageURL);
                    //alert("sucess" + response.imagename);
                    //console.log(response.imageURL);
                    //$('.product-image').removeAttribute("background-image");
                    let label = document.querySelector(`label[for=${fileupload.id}]`);
                    //label.style.backgroundImage = `url(/img/Uploads/Photos/${response.imagename})`;//////////////////forlocalstorage
                    label.style.backgroundImage = `url(${response.imgazureurl})`;//////////////////////////////////for azure storage
                    $('#' + fileupload.id).removeAttr("type");
                    //$('#' + fileupload.id).css("cursor", "not-allowed");
                    //$('#' + fileupload.id).css("value", response.imagename);
                    //document.getElementById(fileupload.id).value = response.imagename;
                     document.getElementById(fileupload.id).value = `/img/Uploads/Photos/${response.imagename}`;//////////////////forlocalstorage
                       // document.getElementById(fileupload.id).value = `${response.imgazureurl}`;//////////////////////////////////for azure storage
                    //console.log($('#' + fileupload.id));
                    //document.getElementById("second-file-upload-btn").value
                    //$("#" + fileupload.id ).css("background-image", "url(/img/Uploads/Photos/" + response.imagename + ")");

                    //console.log(label);
                    //console.log($("#" + fileupload.id));
                    //label.style.backgroundImage = `url(${response.imageURL})`;
                    let productImage = document.querySelector('.product-image');
                    //productImage.removeAttribute("background-image"); 
                   // productImage.style.backgroundImage = `url(/img/Uploads/Photos/${response.imagename})`;//////////////////forlocalstorage
                    productImage.style.backgroundImage = `url(${response.imgazureurl})`;////////////////////////for azure storage
                    //$('.product-image').css('background-image', 'url(~/img/Uploads/Photos/' + response.imagename + ')');
                   //$(".product-image").css("background-image", "url(/img/Uploads/Photos/" + response.imagename + ")");
                    //$('#blah').attr('src', "~/img/Uploads/Photos/" + response.imagename);
                    //$('#blah').attr('src', "~/img/Uploads/Photos/" + response.imagename);
                    $(".product-image").css("background-size", "contain");
                    $(".product-image").css("border", "1px solid red");
                    //console.log($(".product-image"));
                    //console.log(productImage);
                    //console.log(response.imagename);
                    //productImage.style.backgroundImage = `url(${response.imageURL})`;
                    imagePaths[index] = response.imageURL;
                    console.log(imagePaths[index]);
                }
            })
            .fail(function (XMLHttpRequest, textStatus, errorThrown) {
                alert("FAIL");
            });
    });
     
});

// other validate

const productName = document.querySelector('#Name');
const productprice = document.querySelector('#Price');
const productQuantity = document.querySelector('#Quantity');
const productDescription = document.querySelector('#Description');
const productAdminId = document.querySelector('#AdminId');
const productCatId = document.querySelector('#CatId');
const productSubCatId = document.querySelector('#SubCatId');
const productStockId= document.querySelector('#StockId');
const productBrandId = document.querySelector('#BrandId'); 
const validateForm = () => {
    //if (!productName.value.length) {
    //    return showAlert('enter product name');
    //} else if (!des.value.length) {
    //    return showAlert('enter detail description about the product');
    //} else if (!imagePaths.length) { // image link array
    //    return showAlert('upload atleast one product image')
    //} else if (!actualPrice.value.length) {
    //    return showAlert('you must add pricings');
    //} else if (stock.value < 20) {
    //    return showAlert('you should have at least 20 items in stock');
    //} else if (!tags.value.length) {
    //    return showAlert('enter few tags to help ranking your product in search');
    //}
    return true;
}

// upload product or create after make or press submit button 
//$("#saveBtn").click(function () {
//    var model = {
//        Name: $('#Name').val,//productName.text,
//        Price: productprice.val,
//        Quantity: productQuantity.val ,
//        Description: productDescription.val, AdminId: productAdminId.val, CatId: productCatId.val,
//        BrandId: productBrandId.val, StockId: productStockId.val, SubCatId: productSubCatId.val, imgspathes: imagePaths

//    };
//    //if ($("#createProduct").valid()) {
//        $.ajax({
//            type: 'POST',
//            url: '/Products/Create',  
//            data: JSON.stringify(model), 
//            contentType: "application/json"
//        })
//            .done(function (response) {
//                //$("#tableContiner").html(response);
//                //$("#actionContainer").html(""); 
//                focusAction("tableContiner");
//                alert("success "+response);
//            })
//            .fail(function (XMLHttpRequest, textStatus, errorThrown) {
//                alert("FAIL");
//            });
//    //}
//    //else {
//    //    swal({
//    //        title: "Warning",
//    //        text: "Please enter all valid data in fields.",
//    //        icon: "warning",
//    //        buttons: true,
//    //        dangerMode: true,
//    //    });
//   // }
//});



//let user = JSON.parse(sessionStorage.user || null);
    //let loader = document.querySelector('.loader');

    // checknig user is logged in or not
    //window.onload = () => {
    //    if (user) {
    //        if (!compareToken(user.authToken, user.email)) {
    //            location.replace('/login');
    //        }
    //    } else {
    //        location.replace('/login');
    //    }
    //}
    // price inputs
    //const actualPrice = document.querySelector('#actual-price');
    //const discountPercentage = document.querySelector('#discount');
    //const sellingPrice = document.querySelector('#sell-price');
    //discountPercentage.addEventListener('input', () => {
    //    if (discountPercentage.value > 100) {
    //        discountPercentage.value = 90;
    //    } else {
    //        let discount = actualPrice.value * discountPercentage.value / 100;
    //        sellingPrice.value = actualPrice.value - discount;
    //    }
    //})
    //sellingPrice.addEventListener('input', () => {
    //    let discount = (sellingPrice.value / actualPrice.value) * 100;
    //    discountPercentage.value = discount;
    //})

//$('#createProduct').validate({
//    rules: {
//        Name: {
//            required: true,
//            minlength: 5,
//            maxlength: 20,
//        }, Price: {
//            required: true,
//            type: Number,
//            range: [1, 100000]
//        },
//        Description: {
//            required: true,
//            maxlength: 500
//        },
//        Quantity: {
//            required: true,
//            range: [1, 200]
//        }
//    },
//    messages: {
//        Name: {
//            required: 'Name is required',
//            minlength: 'Minimum Length is 5',
//            maxlength: 'Maximum Length is 50'
//        },
//        Description: {
//            required: 'Description is required',
//            maxlength: 'Maximum Length is 500'
//        },
//        Quantity: {
//            required: 'Quantity is required',
//            range: 'Quantity not int range from 1 to 200'
//        },
//        Price: {
//            required: 'Price is required',
//            type:"price is should be number ",
//            range: 'Price must be within range of 1 - 100000.'
//        }
//    }
//});





        //const file = fileupload.files[0];
        //let imageUrl; 
        //if (file.type.includes('image')) {
        //    console.log("inside if file.type.includes");
        //    console.log("file is:" + file);
        //    console.log("file name:" + file.name);
        //    let label = document.querySelector(`label[for=${fileupload.id}]`);
        //    console.log("label:" +label);
        //    console.log("fileupload.id:" +fileupload.id);
        //    label.style.backgroundImage = `url(${file.name})`;
        //    let productImage = document.querySelector('.product-image');
        //    productImage.style.backgroundImage = `url(${file.name})`;
        //    console.log(productImage);

            //if (file.type.includes('image')) {
                // means user uploaded an image
                //fetch('/s3url').then(res => res.json())
                //    .then(url => {
                //        fetch(url, {
                //            method: 'PUT',
                //            headers: new Headers({ 'Content-Type': 'multipart/form-data' }),
                //            body: file
                //        }).then(res => {
                //            imageUrl = url.split("?")[0];
                //            imagePaths[index] = imageUrl;
                //            
                //        })
                //    })
            //}

//        } else {
//            showAlert('upload image only');
//        }
//    })
//})
// generate image upload link
   

// form submission 



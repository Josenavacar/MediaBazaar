<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<meta name="description" content="">
	<meta name="author" content="">

	<title>Stock Management</title>
	<!-- Bootstrap core CSS -->
	<link href="../../bootstrap/css/bootstrap.min.css" type="text/css" rel="stylesheet">
	<!-- Custom styles for this template -->
	<link href="../../css/media_bazaar_css.css" type="text/css" rel="stylesheet">
	<link rel="stylesheet" type="text/css" href="../../css/floating_css.css">
</head>
<body>
    <div class="container-fluid">
    	<div class="col">
	        <h1 class="mt-4 text-center">Edit <?php echo $product['Name']; ?></h1>
			<form>
				<div class="form-group">
					<div class="input-group">
						<div class="col-md-6">
	                        <input id="productName" name="productName" value="<?php echo $product['Name']; ?>" type="text" class="form-control" required="required">
			            </div>
						<div class="col-md-6">
							<input type="hidden" id="productID" name="productID" value="<?= $product['Id'];?>">
	                        <input id="productPrice" name="productPrice" value="<?php echo number_format($product['Price'], 2); ?>" placeholder="Price" type="text" class="form-control" required="required">
			            </div>
	            	</div>
				</div>
	            <div class="form-group">
					<div class="input-group">
						<div class="col-lg">
							<textarea class="form-control" id="description" name="description" rows="3" required="required"><?php echo $product['Description']; ?></textarea>
						</div>
					</div>
	            </div>
	            <div class="input-group">
	                <div class="col-lg">
	                    <button id="submit" type="submit" class="btn btn-md btn-outline-info btn-block submit">Submit</button>
	                </div>
	            </div>  
			</form>
    	</div>
    </div>

  	<!-- /#wrapper -->
	<script src="https://code.jquery.com/jquery-3.5.0.min.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.1/js/bootstrap.bundle.min.js"></script>
	<script type="text/javascript" src="../../js/media_bazaar_js.js"></script>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js" type="text/javascript"></script>

	<script type="text/javascript">
		$(document).ready(function() 
		{
			$("#sidebar-wrapper").hide();
			document.getElementById("backButton").addEventListener("click", function()
			{
				window.history.go(-1);
			});
			$("#menu-toggle").hide();
		});

		/**
		 * Ajax request to PHP to edit a product 
		 * @param  {[type]} event)
		 * @return {[type]}        [description]
		 */
	    $("#submit").click(function (event) 
	    {
	        event.preventDefault();
	        let id = document.getElementById("productID").value;
	        let name = document.getElementById("productName").value;
	        let price = document.getElementById("productPrice").value;
	        let description = document.getElementById("description").value;

	        let data = 
	        {
	        	id: id,
	            name: name,
	            price: price,
	            description: description
	        };

			let url = $(location).attr("href")
			let parts = url.split("/")
			let last_part = '/' + parts[parts.length-3] + '/' + parts[parts.length-2] + '/' + parts[parts.length-1]
			url = url.replace(last_part, '/product/editRequest');

	        $.ajax
	        ({
	            type: "POST",
	            url: url,
	            data: 
	            {
	                edit: data
	            },
	            success: function (data) 
	            {
	            	if(data == 'success')
	            	{
		                Swal.fire
		                ({
		                    icon: 'success',
		                    title: 'Product is successfully updated!'
		                })
	            	}
	            },
	            error: function (data) 
	            {
	                console.log(data);
	            }
	        });
	    });

	</script>
</body>
</html>
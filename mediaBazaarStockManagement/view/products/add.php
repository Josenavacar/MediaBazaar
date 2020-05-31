<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>Stock Management</title>
  <!-- Bootstrap core CSS -->
  <link href="../bootstrap/css/bootstrap.min.css" type="text/css" rel="stylesheet">
  <!-- Custom styles for this template -->
  <link href="../css/media_bazaar_css.css" type="text/css" rel="stylesheet">
  <link rel="stylesheet" type="text/css" href="../css/floating_css.css">
</head>
<body>
    <div class="container-fluid">
    	<div class="col">
        	<h1 class="mt-4 text-center">Add a new product</h1>
			<form>
				<div class="form-group">
					<div class="input-group">
						<div class="col-md-6">
							<div class="form-label-group">
		                        <input id="name" name="name" placeholder="Enter name here..." type="text" class="form-control" required="required">
		                        <label for="name">Name</label>
	                        </div>
			            </div>
						<div class="col-md-6">
							<div class="form-label-group">
	                        	<input id="price" name="price" placeholder="Price" type="text" class="form-control" required="required">
	                        	<label for="price">Price</label>
                        	</div>
			            </div>
	            	</div>
				</div>
	            <div class="form-group">
					<div class="input-group">
						<div class="col-lg">
							<textarea class="form-control" id="description" placeholder="Description" name="description" rows="3" required="required"></textarea>
						</div>
					</div>
	            </div>
	            <div class="form-group">
	            	<div class="input-group">
	            		<div class="col-lg">
		                    <select id="categories" class="form-control" required="true">
		                        <option hidden >Categories</option>
			                        <?php foreach($categories as $category) { ?>
			                            <option data-id="<?php echo $category['Id']; ?>" value="<?php echo $category['Name'] ?>" id="category"><?php echo $category["Name"] ?></option>
			                        <?php } ?>
		                    </select>
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
</div>
<!-- /#page-content-wrapper -->
</div>
  <!-- /#wrapper -->

	<!-- Bootstrap core JavaScript -->
	<script src="../jquery/jquery.min.js"></script>
	<script src="../bootstrap/js/bootstrap.bundle.min.js"></script>
	<script type="text/javascript" src="../js/media_bazaar_js.js"></script>
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
		 * Ajax request to PHP to add product to the DB
		 * @param  {[type]} event) 	                {	        event.preventDefault();	        let name [description]
		 * @return {[type]}        [description]
		 */
	    $("#submit").click(function (event) 
	    {
	        event.preventDefault();
	        let name = document.getElementById("name").value;
	        let price = document.getElementById("price").value;
	        let description = document.getElementById("description").value;
	        let category = $('#categories').find(':selected').attr('data-id');

	        let data = 
	        {
	            name: name,
	            price: price,
	            description: description,
	            category: category
	        };

			let url = $(location).attr("href")
			let parts = url.split("/")
			let last_part = '/' + parts[parts.length-1]
			url = url.replace(last_part, '/addRequest');

	        if ((name === "") || (description === "") || (price === "") || (category === "")) 
	        {
	            Swal.fire
	            ({
	                icon: 'error',
	                title: 'Request failed',
	                html: "All fields needs to be filled and selected!"
	            })
	        }
	        else
	        {
		        $.ajax
		        ({
		            type: "POST",
		            url: url,
		            data: 
		            {
		                add: data
		            },
		            success: function (data) 
		            {
		            	if(data == 'success')
		            	{
			                Swal.fire
			                ({
			                    icon: 'success',
			                    title: 'New product is added',
			                })
		            	}
		            },
		            error: function (data) 
		            {
		                console.log(data);
		            }
		        });

	        }
	    });

	</script>
</body>
</html>
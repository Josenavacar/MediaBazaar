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
        <h1 class="mt-4 text-center">Add a new category</h1>
		<form>
			<div class="form-group">
				<div class="input-group">
					<div class="col-lg">
                        <input id="categoryName" name="categoryName" placeholder="Enter name here..." type="text" class="form-control" required="required">
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
            <div class="input-group">
                <div class="col-lg">
                    <button id="submit" type="submit" class="btn btn-md btn-outline-info btn-block submit">Submit</button>
                </div>
            </div>  
		</form>
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


	    $("#submit").click(function (event) 
	    {
	        event.preventDefault();
	        let name = document.getElementById("categoryName").value;
	        let description = document.getElementById("description").value;

	        let data = 
	        {
	            name: name,
	            description: description
	        };

	        $.ajax
	        ({
	            type: "POST",
	            url: "http://localhost/mediabazaar/mediaBazaarStockManagement/category/addRequest",
	            data: 
	            {
	                data: data
	            },
	            success: function (data) 
	            {
	                Swal.fire
	                ({
	                    icon: 'success',
	                    title: 'New category is added',
	                })
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
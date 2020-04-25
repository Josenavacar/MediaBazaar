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
            <h1 class="mt-4">Products</h1>
			<div class="table-responsive">
				<table class="table table-hover">
					<thead class="table-primary">
						<tr>
                            <th scope="col">Product ID</th>
							<th scope="col">Name</th>
							<th scope="col">Price Per Unit</th>
						</tr>
					</thead>
					<tbody>
						<?php foreach ($products as $product) { ?>
							<tr>
								<td><?php echo $product['Id']; ?></td>
                                <td><?php echo $product['Name']; ?></td>
                                <td><?php echo $product['Price']; ?></td>
							</tr>
						<?php } ?>
					</tbody>
				</table>				
			</div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
</div>
  <!-- /#wrapper -->

<!-- Bootstrap core JavaScript -->
<script src="https://code.jquery.com/jquery-3.5.0.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.4.1/js/bootstrap.bundle.min.js"></script>
<script type="text/javascript" src="../../js/media_bazaar_js.js"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js" type="text/javascript"></script>

<script type="text/javascript">
	$(document).ready(function() 
	{
		$("#sidebar-wrapper").hide();
		document.getElementById("backButton").addEventListener("click", function(){
			window.history.go(-1);
		});
		$("#menu-toggle").hide();
	});
</script>
</body>

</html>
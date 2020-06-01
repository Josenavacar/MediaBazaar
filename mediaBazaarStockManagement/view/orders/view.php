<?php 
	if(isset($_SESSION['order_ID']))
	{
		$order_ID = $_SESSION['order_ID'];
	}
	else 
	{
		$order_ID = "";
	}
?>
<div class="container-fluid">
    <h1 class="mt-4">Orders</h1>
	<div class="table-responsive">
		<div class="input-group mb-3">
			<input type="text" class="form-control" id="myInput" placeholder="Search by order ID..">
            <span class="input-group-append">
                <span class="btn btn-secondary">
                    <i class="fa fa-search"></i>
                </span>
            </span>
		</div>

		<table class="table table-hover" id="myTable">
			<thead class="table-primary">
				<tr class="header">
                    <th scope="col">Order ID</th>
					<th scope="col">Name</th>
                    <th scope="col">Quantity</th>
					<th scope="col">Total Price</th>
                    <th scope="col">Price Per Unit</th>
                    <th scope="col">Order Date</th>
				</tr>
			</thead>
			<tbody>
				<?php foreach ($orders as $order) { ?>
					<tr>
						<td><?php echo "OD-ID ". $order['OrderID']; ?></td>
                        <td><?php echo $order['Name']; ?></td>
                        <td><?php echo $order['Quantity']; ?></td>
						<td><?php echo "€" . " " . $order['TotalPrice']; ?></td>
                        <td><?php echo "€" . " " . number_format($order['Price'], 2); ?></td>
                        <td><?php echo date("F j, Y", strtotime($order['OrderDate'])); ?></td>
					</tr>
				<?php } ?>
			</tbody>
			<div class="alert alert-success orderAlert" role="alert">
			</div>
		</table>				
	</div>
</div>
<br>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js" type="text/javascript"></script>
<script type="text/javascript">
	document.getElementById("myInput").addEventListener("keyup", myFunction);
	let orderID = '<?php echo $order_ID; ?>'

	if(orderID == "")
	{
		$(".orderAlert").hide();
	}
	else
	{
		$(".orderAlert").text('Your order ID: ' + orderID);
		$(".orderAlert").fadeOut( 2500 );
	}
	
	function myFunction() 
	{
		// Write on keyup event of keyword input element
        let searchText = $(this).val().toLowerCase();
        // Show only matching TR, hide rest of them
        $.each($("#myTable tbody tr"), function() 
        {
            if($(this).text().toLowerCase().indexOf(searchText) === -1)
            {
               // $('.notfound').show();
               $(this).hide();
            }
            else
            {
            	// $('.notfound').hide();
                $(this).show();
            }
        });
	}
</script>

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
						</tr>
					</thead>
					<tbody>
						<?php foreach ($orders as $order) { ?>
							<tr>
								<td><?php echo "OD-ID ". $order['OrderID']; ?></td>
                                <td><?php echo $order['Name']; ?></td>
                                <td><?php echo $order['Quantity']; ?></td>
								<td><?php echo "€" . " " . $order['TotalPrice']; ?></td>
                                <td><?php echo "€" . " " . $order['Price']; ?></td>
							</tr>
						<?php } ?>
					</tbody>
				</table>				
			</div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
</div>

<script type="text/javascript">
	document.getElementById("myInput").addEventListener("keyup", myFunction);

	function myFunction() {
	  var input, filter, table, tr, td, i, txtValue;
	  input = document.getElementById("myInput");
	  filter = input.value.toUpperCase();
	  table = document.getElementById("myTable");
	  tr = table.getElementsByTagName("tr");
	  for (i = 0; i < tr.length; i++) {
	    td = tr[i].getElementsByTagName("td")[0];
	    if (td) {
	      txtValue = td.textContent || td.innerText;
	      if (txtValue.toUpperCase().indexOf(filter) > -1) {
	        tr[i].style.display = "";
	      } else {
	        tr[i].style.display = "none";
	      }
	    }       
	  }
	}
</script>

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
								<td id="price"><?php echo "€" . " " . $product['Price']; ?></td>
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
	$(document).ready(function() {
		let price = document.getElementById("#price");
		alert(price)

	    function numberWithCommas(x) 
	    {
	        return '\u20AC ' + x.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
	    }
	});
</script>


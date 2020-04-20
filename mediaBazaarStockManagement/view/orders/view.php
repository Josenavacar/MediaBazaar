        <div class="container-fluid">
            <h1 class="mt-4">Orders</h1>
			<div class="table-responsive">
				<table class="table table-hover">
					<thead class="table-primary">
						<tr>
                            <th scope="col">Order ID</th>
							<th scope="col">Name</th>
                            <th scope="col">Quantity</th>
							<th scope="col">Price</th>
						</tr>
					</thead>
					<tbody>
						<?php foreach ($orders as $order) { ?>
							<tr>
								<td><?php echo $order['OrderID']; ?></td>
                                <td><?php echo $order['Name']; ?></td>
                                <td><?php echo $order['Quantity']; ?></td>
								<td><?php echo "€" . " " . $order['TotalPrice']; ?></td>
							</tr>
						<?php } ?>
					</tbody>
				</table>				
			</div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
</div>


        <div class="container-fluid">
            <h1 class="mt-4">Stock Management</h1>
			<div class="table-responsive">
				<table class="table table-hover">
					<thead class="table-primary">
						<tr>
                            <th scope="col">Product ID</th>
							<th scope="col">Name</th>
							<th scope="col">Price</th>
							<th scope="col">Units In Stock</th>
						</tr>
					</thead>
					<tbody>
						<?php foreach ($units as $unit) { ?>
							<tr>
                                <td><?php echo $unit['Id']; ?></td>
								<td><?php echo $unit['Name']; ?></td>
								<td><?php echo "€" . " " . $unit['Price']; ?></td>
								<td><?php echo $unit['UnitsInStock']; ?></td>
							</tr>
						<?php } ?>
					</tbody>
				</table>				
			</div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
</div>


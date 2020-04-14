        <div class="container-fluid">
            <h1 class="mt-4">Products</h1>
			<div class="table-responsive">
				<table class="table table-hover">
					<thead class="table-primary">
						<tr>
                            <th scope="col">Product ID</th>
							<th scope="col">Name</th>
							<th scope="col">Price</th>
						</tr>
					</thead>
					<tbody>
						<?php foreach ($products as $product) { ?>
							<tr>
                                <td><?php echo $product['Id']; ?></td>
								<td><?php echo $product['Name']; ?></td>
								<td><?php echo "€" . " " . $product['Price']; ?></td>
							</tr>
						<?php } ?>
					</tbody>
				</table>				
			</div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
</div>


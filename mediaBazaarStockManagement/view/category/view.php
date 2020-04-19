        <div class="container-fluid">
            <h1 class="mt-4">Products</h1>
			<div class="table-responsive">
				<table class="table table-hover">
					<thead class="table-primary">
						<tr>
                            <th scope="col">Order ID</th>
							<th scope="col">Name</th>
                            <th scope="col">Category</th>
						</tr>
					</thead>
					<tbody>
						<?php foreach ($categories as $category) { ?>
							<tr>
								<td><?php echo $category['Id']; ?></td>
                                <td><?php echo $category['Name']; ?></td>
                                <td><?php echo $category['Category']; ?></td>
							</tr>
						<?php } ?>
					</tbody>
				</table>				
			</div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
</div>


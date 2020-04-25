        <div class="container-fluid">
            <h1 class="mt-4">Categories</h1>
			<div class="table-responsive">
				<table class="table table-hover">
					<thead class="table-primary">
						<tr>
                            <th scope="col">Category ID</th>
							<th scope="col">Name</th>
                            <th scope="col">Description</th>
						</tr>
					</thead>
					<tbody>
						<?php foreach ($categories as $category) { ?>
							<tr>
								<td><?php echo "CAT-NR " . $category['Id']; ?></td>
                                <td><a href="category/product/<?=$category['Id']?>"><?php echo $category['Name']; ?></a></td>
                                <td><?php echo $category['Description']; ?></td>
							</tr>
						<?php } ?>
					</tbody>
				</table>				
			</div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
</div>


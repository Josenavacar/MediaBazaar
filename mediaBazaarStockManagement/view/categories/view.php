        <div class="container-fluid">
            <h1 class="mt-4">Categories</h1>
			<div class="table-responsive">
				<div class="input-group mb-3">
					<input type="text" class="form-control" id="myInput" placeholder="Search by category ID..">
		            <span class="input-group-append">
		                <span class="btn btn-secondary">
		                    <i class="fa fa-search"></i>
		                </span>
		            </span>
				</div>
				<table class="table table-hover" id="myTable">
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
								<td><?php echo "CAT-ID " . $category['Id']; ?></td>
                                <td><a href="category/product/<?=$category['Id']?>"><?php echo $category['Name']; ?></a></td>
                                <td><?php echo $category['Description']; ?></td>
							</tr>
						<?php } ?>
					</tbody>
				</table>
                <div class="input-group">
                    <div class="col-lg-6 mb-3">
                        <a href="category/add" class="btn btn-md btn-outline-info btn-block">Add a category</a>
                    </div>
                </div> 				
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

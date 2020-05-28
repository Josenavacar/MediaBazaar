<div class="container-fluid">
    <h1 class="mt-4">Products</h1>
	<div class="table-responsive">
		<div class="input-group mb-3">
			<input type="text" class="form-control" id="myInput" placeholder="Search by product ID..">
            <span class="input-group-append">
                <span class="btn btn-secondary">
                    <i class="fa fa-search"></i>
                </span>
            </span>
		</div>

		<table class="table table-hover" id="myTable">
			<thead class="table-primary">
				<tr class="header">
                    <th scope="col">Product ID</th>
					<th scope="col">Name</th>
					<th scope="col">Price Per Unit</th>
					<th scope="col"></th>
				</tr>
			</thead>
			<tbody>
				<?php foreach ($products as $product) { ?>
					<tr>
                        <td><?php echo "PR-ID " . $product['Id']; ?></td>
                        <td><a href="product/product/<?=$product['Id']?>"><?php echo $product['Name']; ?></a></td>
						<td id="price"><?php echo "€" . " " . number_format($product['Price'], 2); ?></td>
						<td><a class="btn btn-outline-dark" href="product/edit/<?=$product['Id']?>">Edit</a></td>
					</tr>
				<?php } ?>
			</tbody>
		</table>		
        <div class="input-group">
            <div class="col-lg-6 mb-3"> 
                <a href="product/add" class="btn btn-md btn-outline-info btn-block">Add product</a>
            </div>
        </div> 			
	</div>
</div>
<br>

<script type="text/javascript">
    document.getElementById("myInput").addEventListener("keyup", myFunction);

	function myFunction() 
	{
	  var input, filter, table, tr, td, i, txtValue;
	  input = document.getElementById("myInput");
	  filter = input.value.toUpperCase();
	  table = document.getElementById("myTable");
	  tr = table.getElementsByTagName("tr");

	  for (i = 0; i < tr.length; i++) 
	  {
	    td = tr[i].getElementsByTagName("td")[0];
	    if (td) 
	    {
	      txtValue = td.textContent || td.innerText;
	      if (txtValue.toUpperCase().indexOf(filter) > -1) 
	      {
	        tr[i].style.display = "";
	      } 
	      else 
	      {
	        tr[i].style.display = "none";
	      }
	    }       
	  }
	}

	$(document).ready(function() {
		let price = document.getElementById("#price").value;
		// alert(price)

	    function numberWithCommas(x) 
	    {
	        return '\u20AC ' + x.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
	    }
	});
</script>


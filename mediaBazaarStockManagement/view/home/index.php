        <div class="container-fluid">
            <h1 class="mt-4">Inventory</h1>
            <div class="row">
				<div class="input-group mb-3">
					<input type="text" class="form-control" id="myInput" placeholder="Search by product ID..">
		            <span class="input-group-append">
		                <span class="btn btn-secondary">
		                    <i class="fa fa-search"></i>
		                </span>
		            </span>
				</div>
	            <div class="col">
					<div class="table-responsive">
						<table class="table table-hover" id="myTable">
							<thead class="table-primary">
								<tr>
		                            <th scope="col">Product ID</th>
									<th scope="col">Name</th>
									<th scope="col">Price Per Unit</th>
									<th scope="col">Units In Stock</th>
								</tr>
							</thead>
							<tbody>
								<?php foreach ($units as $unit) { ?>
									<tr>
		                                <td><?php echo "PR-ID " .  $unit['Id']; ?></td>
										<td><?php echo $unit['Name']; ?></td>
										<td><?php echo "€" . " " . $unit['Price']; ?></td>
										<td><?php echo $unit['UnitsInStock']; ?></td>
									</tr>
								<?php } ?>
							</tbody>
						</table>
					</div>	
	            </div>
	            <div class="col">
					<div id="piechart" class="piechart"></div>
	            </div>
            </div>
			</div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
</div>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js" type="text/javascript"></script>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
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

	// Load google charts
	google.charts.load('current', {'packages':['corechart']});
	google.charts.setOnLoadCallback(drawChart);

	// Draw the chart and set the chart values
	function drawChart() 
	{       
		var data = google.visualization.arrayToDataTable
		([
		 	['Task', 'Hours per Day'],
		 	<?php 
		 		foreach ($units as $key) {
		 			$stock = $key['UnitsInStock'];
		 			$name = $key['Name'];
		 			echo "['$name', $stock],";
		 		}
		 	?>
		]);

		  // Optional; add a title and set the width and height of the chart
	  	var options = 
	  	{
		  	'title':'My Average Day', 
		  	is3D: true,       
		  	chartArea: 
		  	{
		        top: 0,
		        right: -250,
		        bottom: 0,
		        left: 0,
		        height: '100%',
		        width: '100%'
	      	}
		};

		// Display the chart inside the <div> element with id="piechart"
		var chart = new google.visualization.PieChart(document.getElementById('piechart'));
		chart.draw(data, options);
	}
</script>

<div class="container-fluid">
    <h1 class="mt-4">Inventory</h1>
    <hr>
	<div id="saleStats" class="row">
		<div class="col-sm-6">
			<div class="card card bg-light">
				<div class="card-header">Historical: Best Selling Products</div>
				<div class="card-body text-info">
					<?php foreach ($bestSellingProducts as $product) { ?>
						<p class="card-text"><?php echo $product['Name']; ?></p>
					<?php } ?>
				</div>
			    <div class="card-footer">
			        <small class="text-muted"></small>
			    </div>
			</div>
		</div>
		<div class="col">
			<div class="card card bg-light">
				<div class="card-header">Historical: Total number of orders</div>
				<div class="card-body text-info">
					<p class="card-text"><?php echo count($orders); ?></p>
				</div>
			    <div class="card-footer">
			        <small class="text-muted"></small>
			    </div>
			</div>
			<br>
			<div class="card card bg-light">
				<div class="card-header">Total number of products in system</div>
				<div class="card-body text-info">
					<p class="card-text"><?php echo count($products); ?></p>
				</div>
			    <div class="card-footer">
			        <small class="text-muted"></small>
			    </div>
			</div>
		</div>
		<div class="col">
			<div class="card card bg-light">
				<div class="card-header">Total orders so far for the month of <?php echo date("F"); ?></div>
				<div class="card-body text-info">
					<p class="card-text"><?php echo count($ordersPerMonth); ?></p>
				</div>
			    <div class="card-footer">
			        <small class="text-muted"></small>
			    </div>
			</div>
			<br>
			<div class="card card bg-light">
				<div class="card-header">Total number of categories in system</div>
				<div class="card-body text-info">
					<p class="card-text"><?php echo count($categories); ?></p>
				</div>
			    <div class="card-footer">
			        <small class="text-muted"></small>
			    </div>
			</div>
		</div>
	</div>
	<hr>
    <div class="row">
        <div class="col">
			<div class="table-responsive">
				<div class="input-group mb-3">
					<input type="text" class="form-control" id="myInput" placeholder="Search by product ID..">
		            <span class="input-group-append">
		                <span class="btn btn-secondary">
		                    <i class="fa fa-search"></i>
		                </span>
		            </span>
				</div>
				<table class="table table-hover table-bordered" id="myTable">
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
                                <td id="pid"><?php echo "PR-ID " .  $unit['Id']; ?></td>
								<td><a href="product/product/<?=$unit['Id']?>"><?php echo $unit['Name']; ?></a></td>
								<td><?php echo "€" . " " . number_format($unit['Price'], 2); ?></td>
								<?php if ($unit['UnitsInStock'] > 200) 
								{
									echo '<td>'.$unit['UnitsInStock'].'</td>';
								}
								else
								{
									echo '<td data-toggle="tooltip" title="Units in stock: '.$unit['UnitsInStock'].'"><span class="badge badge badge-danger">Low on supplies!</span></td>';
								} 
								?>
							</tr>
						<?php } ?>
						   <!-- Display this <tr> when no record found while search -->
					</tbody>
				</table>
			</div>
        </div>

        <div class="col">
			<h6>Price per unit in euros</h6>
			<div id="barchart"></div>
			<hr>
			<h6>Products with a low supply</h6>
			<div id="curve_chart"></div>
        </div>
    </div>
    <hr>
    <br>
</div>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js" type="text/javascript"></script>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

<script type="text/javascript">
    document.getElementById("myInput").addEventListener("keyup", myFunction);
    google.charts.load("current", {packages:["corechart"]});
    google.charts.setOnLoadCallback(drawBarChart);
  	// google.charts.setOnLoadCallback(drawHistoChart);
	google.charts.setOnLoadCallback(drawLineChart);

	$(document).ready(function() 
	{
		let timePassed = 1
		$(".text-muted").text('Last update' + ' ' +timePassed + ' ' + 'minute ago');

		setInterval(function()
		{
			timePassed++
		    $("#saleStats")
		    $(".text-muted").text('Last update' + ' ' +timePassed + ' ' + 'minutes ago');
		}, 60000);
	});

  	/**
  	 * [myFunction description]
  	 * @return {[type]} [description]
  	 */
	function myFunction() 
	{
		// Write on keyup event of keyword input element
        let searchText = $(this).val().toLowerCase();
        // Show only matching TR, hide rest of them
        $.each($("#myTable tbody tr"), function() 
        {
            if($(this).text().toLowerCase().indexOf(searchText) === -1)
            {
               // $('.notfound').show();
               $(this).hide();
            }
            else
            {
                $(this).show();
            }
        });
	}

	/**
	 * [drawBarChart description]
	 * @return {[type]} [description]
	 */
    function drawBarChart() 
    {
        let data = google.visualization.arrayToDataTable
        ([
	        ["Product", "Price", { role: "style" } ],
		 	<?php 
		 		foreach ($units as $key) 
		 		{
		 			$price = $key['Price'];
		 			$name = $key['Name'];
		 			echo "['$name', $price, 'stroke-color: #C5A5CF; stroke-width: 4; fill-color: #703593'],";
		 		}
		 	?>
        ]);

		let options = 
		{
			bar: 
			{
				groupWidth: "95%"
			},
			legend: 
			{ 
				position: "none" 
			}
		};

		let chart = new google.visualization.BarChart(document.getElementById("barchart"));
		chart.draw(data, options);
    }

  	/**
  	 * [drawLineChart description]
  	 * @return {[type]} [description]
  	 */
	function drawLineChart() 
	{
		let data = google.visualization.arrayToDataTable
		([
			['Product', 'The amount of units in stock'],
			<?php 
				foreach ($units as $key) 
				{
					if($key['UnitsInStock'] < 200)
					{
						$stock = $key['UnitsInStock'];
						$name = $key['Name'];
						echo "['$name', $stock],";
					}
				}
			?>
		]);

		var options = 
		{
			legend: { position: 'top' },
			width: 650,
			height: 550,
			pointSize: 10,
		};

		let chart = new google.visualization.LineChart(document.getElementById('curve_chart'));
		chart.draw(data, options);
	}

    /**
     * [drawHistoChart description]
     * @return {[type]} [description]
     */
  	function drawHistoChart() 
  	{
        let data = google.visualization.arrayToDataTable
        ([
          ['Product', 'Units in stock'],
      	 	<?php 
		 		foreach ($units as $key) 
		 		{
		 			if($key['UnitsInStock'] < 200)
		 			{
		 				$stock = $key['UnitsInStock'];
			 			$name = $key['Name'];
		 				echo "['$name', $stock],";
		 			}
		 		}
	 		?>
      	]);

        let options = 
        {
            legend: 
            { 
            	position: 'top' 
            }
        };

        let chart = new google.visualization.Histogram(document.getElementById('histochart'));
        chart.draw(data, options);
  	}
</script>

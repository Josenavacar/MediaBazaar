        <div class="container-fluid">
            <div class="request-form">
                <form id="stockRequestForm" method="POST">
                    <h2 class="text-center">Stock Request</h2>
                    <hr>   
                    <div class="form-group">
                        <div class="input-group">
                            <div class="col-lg-6 mb-3">
                                <div class="form-label-group">
                                    <input id="email" name="email" placeholder="Email" type="text" class="form-control">
                                    <label>Email</label>
                                </div>                                
                            </div>

                            <select class="form-control">
                                <option hidden >Departments</option>
                                <?php foreach($departments as $department) { ?>
                                    <option id="department"><?php echo $department["Name"] ?></option>
                                <?php } ?>
                            </select>
                        </div>

                        <div class="input-group">
                            <div class="col-lg-6 mb-3">
                                <select id="products" class="form-control">
                                    <option hidden >Products</option>
                                    <?php foreach($products as $product) { ?>
                                        <option data-price="<?php echo $product["Price"]; ?>" value="<?php echo $product["Name"]; ?>" id="product"> <?php echo $product["Name"] ?></option>
                                    <?php } ?>
                                </select>                              
                            </div>

                            <select id="quantity" class="form-control">
                                <option hidden >Quantity</option>
                                <option value="100">100</option>
                                <option value="200">200</option>
                                <option value="300">300</option>
                                <option value="400">400</option>
                                <option value="500">500</option>
                            </select>
                        </div>

                        <div class="input-group">
                            <div class="col-lg-6 mb-3">
                                <div class="form-label-group">
                                    <input id="total_price" placeholder="Price" type="text" class="form-control">
                                    <label>Price</label>
                                </div>    
                            </div>
                        </div>
                    </div>     
                    <div class="input-group">
                        <div class="col-lg-6 mb-3">
                            <button id="submit" type="submit" class="btn btn-md btn-outline-info btn-block submit">Submit</button>
                        </div>
                    </div>  
                </form>
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
</div>

<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js" type="text/javascript"></script>
<script type="text/javascript">
    document.getElementById("quantity").addEventListener("change", getQuantity);

    function getQuantity()
    {
        calculateTotalPrice();
    }

    function calculateTotalPrice() 
    {
        let price = $('#products').find(':selected').attr('data-price');
        let quantity = document.getElementById("quantity").value;
        let totalPrice = quantity * price;
        document.getElementById("total_price").value = totalPrice;
        return totalPrice;
    }

    $("#submit").click(function (event) 
    {
        event.preventDefault();
        let totalPrice = calculateTotalPrice();
        let email = document.getElementById("email").value;
        let department = document.getElementById("department").value;
        let product = document.getElementById("products").value;
        let data = 
        {
            totalPrice: totalPrice, 
            email: email,
            department: department,
            product: product
        };

        $.ajax
        ({
            type: "POST",
            url: "http://localhost/mediabazaar/mediaBazaarStockManagement/stock/stockrequest",
            
            data: 
            {
                data: data
            },
            success: function (data) 
            {
                // console.log(data);
                window.location.href = "http://localhost/mediabazaar/mediaBazaarStockManagement/stock/result";
            },
            error: function (data) 
            {
                console.log(data);
            }
        });
    });
</script>
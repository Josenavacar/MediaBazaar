    <div class="container-fluid">
        <div class="row align-items-center">

            <div class="col-12 col-md-6 offset-xl-2 offset-md-1 order-md-2 mb-5 mb-md-0">
                <!-- Image -->
                <!-- <div id="clock"></div> -->
                <div class="text-center">
                    <img src="images/warehouse-industrial.jpg" alt="..." class="img-fluid">
                </div>
            </div>

            <div class="col-12 col-md-5 col-xl-4 order-md-1 my-5">
                <div class="login-form">
                    <form action="<?= URL ?>login/login" method="post">
                        <div class="avatar">
                            <img src="images/project_logo.png" alt="">
                        </div>
                        <h2 class="text-center">Login</h2>   
                        <div class="form-label-group">
                            <input type="text" class="form-control" name="passcode" placeholder="Passcode" required="required">
                            <label>Passcode</label>
                        </div>       
                        <div class="form-group">
                            <button type="submit" class="btn btn-primary btn-lg btn-block">Sign in</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
</div>
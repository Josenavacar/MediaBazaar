        <div class="container-fluid">
            <div class="login-form">
                <form action="<?= URL ?>login/login" method="post">
                    <div class="avatar">
                        <img src="images/project_logo.png" alt="">
                    </div>
                    <h2 class="text-center">Login</h2>   
                    <div class="form-group">
                        <input type="text" class="form-control" name="passcode" placeholder="Please enter passcode here..." required="required">
                    </div>       
                    <div class="form-group">
                        <button type="submit" class="btn btn-primary btn-lg btn-block">Sign in</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <!-- /#page-content-wrapper -->
</div>
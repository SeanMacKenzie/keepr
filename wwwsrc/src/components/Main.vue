<template>
    <div class="main container-fluid">
        <div class="row banner">
            <div class="col-sm-3 product">
                <h4>keepr.</h4>
            </div>
            <div class="col-sm-6 text-center welcome" v-if="user.username != null">
                <h2>Welcome {{user.username}}</h2>

            </div>
            <div class="col-sm-6 text-center welcome" v-else>
                <h2>Welcome to keepr.</h2>
            </div>
            <div class="col-sm-3 login bottom-align-text loginbutton" id="login" v-if="user.username == null">
                <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#loginModal">Login</button>
                <div class="modal fade" id="loginModal" tabindex="-1" role="dialog" aria-labelledby="loginModalLabel">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <h4 class="modal-title" id="loginModal">Login</h4>
                            </div>
                            <div class="modal-body">
                                <form class="form" id="login" @submit.prevent="submitLogin">
                                    <div class="form-group">
                                        <label for="email">Email</label>
                                        <input class="form-control" type="email" name="email" placeholder="yourname@email.com" v-model='login.email' required>
                                    </div>
                                    <div class="form-group">
                                        <label for="password">Password</label>
                                        <input class="form-control" type="password" name="password" placeholder="password" v-model='login.password' required>
                                    </div>
                                    <div class="form-group">
                                        <button type="submit" class="btn btn-default btn-success" data-toggle="modal" data-backdrop="false">Login</button>
                                    </div>
                                </form>
                            </div>
                            <div class="modal-footer">
                                <button type="submit" class="btn btn-default btn-success pull-left" data-dismiss="modal" data-target="#loginModal">
                                    <span class="glyphicon glyphicon-remove"></span>Cancel</button>
                                <p>Need to register?
                                    <button type="button" class="btn btn-default" @click="changeUp">Sign Up</button>
                                </p>
                                <div id="reg">
                                    <form class="form" id="registration" @submit.prevent="submitRegister">
                                        <div class="form-group">
                                            <label for="username">Username</label>
                                            <input type="text" class="form-control" name="username" placeholder="Name" v-model='register.username' required>
                                        </div>
                                        <div class="form-group">
                                            <label for="email">Email</label>
                                            <input type="email" class="form-control" name="email" placeholder="yourname@email.com" v-model='register.email' required>
                                        </div>
                                        <div class="form-group">
                                            <label for="password">Password</label>
                                            <input type="password" class="form-control" name="password" placeholder="password" v-model='register.password' required>
                                        </div>
                                        <div class="form-group">
                                            <button type="submit" class="btn btn-default btn-success" data-toggle="modal" data-backdrop="false">Register</button>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-3 logout" v-else>
                <button type="button" class="btn btn-lg btn-danger" @click="logout">Logout</button>
            </div>
        </div>
        <div class="row navigation" v-if="user.username != null">
            <div class="col-md-12 text-center">
                <button class="btn btn-lg btn-success">
                    <router-link :to="'Dashboard'">Visit Dashboard</router-link>
                </button>
            </div>
        </div>
        <keeps></keeps>

    </div>


</template>

<script>
    import Keeps from '@/components/Keeps'
    export default {
        name: 'Main',
        data() {
            return {
                login: {
                    email: '',
                    password: ''
                },
                register: {
                    username: '',
                    email: '',
                    password: ''
                },

            }
        },
        computed: {
            error() {
                return this.$store.state.error.message
            },
            user() {
                return this.$store.state.user
            }
        },
        methods: {
            submitLogin() {
                this.$store.dispatch('submitLogin', this.login)
                this.login = {
                    email: '',
                    password: ''
                }
            },
            submitRegister() {
                this.$store.dispatch('submitRegister', this.register)
                this.register = {
                    username: '',
                    email: '',
                    password: ''
                }
            },
            changeUp() {
                var x = document.getElementById('reg');
                if (x.style.display === 'block') {
                    x.style.display = 'none';
                } else {
                    x.style.display = 'block';
                }
            },
            logout() {
                this.$store.dispatch('logout')
            },


        },
        components: {
            Keeps
        }

    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
    @import url('https://fonts.googleapis.com/css?family=Audiowide|Kavivanar|Source+Code+Pro');
    .banner {
        background-color: black;
    }

    .product {
        font-family: 'Audiowide', cursive;
        padding-top: 3em;
        color: #8d9229;
    }

    .welcome {
        font-family: 'Audiowide', cursive;
        padding-top: 1em;
        color: #8d9229;
    }

    .loginbutton {
        padding-top: 1em;
        color: #8d9229;
        font-family: 'Audiowide', cursive;
    }

    .logout {
        padding-top: 1em;
        font-family: 'Audiowide', cursive;
        color: #8d9229;
    }



    #reg {
        display: none;
    }
</style>
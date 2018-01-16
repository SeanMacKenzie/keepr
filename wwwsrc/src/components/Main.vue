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
            <div class="col-sm-3 login" id="login" v-if="user.username == null">
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
                                            <input type="text" class="form-control" name="username" placeholder="Name" v-model='register.name' required>
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
            <div class="col-md-6 text-center">
                <button class="btn btn-lg btn-success">
                    <router-link :to="'Dashboard'">Manage your Vaults</router-link>
                </button>
            </div>
            <div class="col-md-6 text-center">
                <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#createKeepModal">Create a new Keep</button>
                <div class="modal fade" id="createKeepModal" tabindex="-1" role="dialog" aria-labelledby="createKeepModalLabel">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                                <h4 class="modal-title" id="createKeep">Create Keep</h4>
                            </div>
                            <div class="modal-body">
                                <form class="form" id="keep" @submit.prevent="createKeep">
                                    <div class="form-group">
                                        <label for="name">Title</label>
                                        <input type="text" class="form-control" name="name" placeholder="Title" v-model='newKeep.name' required>
                                    </div>
                                    <div class="form-group">
                                        <label for="description">Description</label>
                                        <input type="text" class="form-control" name="description" placeholder="Description" v-model='newKeep.description'>
                                    </div>
                                    <div class="form-group">
                                        <label for="image">Image Url</label>
                                        <input type="text" class="form-control" name="image" placeholder="ImageUrl" v-model='newKeep.image' required>
                                    </div>
                                    <div class="form-group">
                                        <button type="submit">Submit</button>
                                    </div>
                                </form>
                            </div>
                            <div class="modal-footer">
                                <button type="submit" class="btn btn-default btn-success center" data-dismiss="modal" data-target="createKeepModal">
                                    <span class="glyphicon glyphicon-remove"></span>Cancel
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</template>

<script>
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
                newKeep: {
                    name: '',
                    description: '',
                    image: '',
                    shares: '',
                    userId: ''
                }

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

            createKeep() {
                this.newKeep.userId = this.user._id
                this.$store.dispatch('createKeep', this.newKeep)
                this.newKeep = {
                    name: '',
                    description: '',
                    image: '',
                    shares: '',
                    userId: ''
                }
            },
        },
        computed: {
            error() {
                return this.$store.state.error.message
            },
            user() {
                return this.$store.state.user
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
    .banner {
        background-color: black;
        vertical-align: bottom;

    }

    #reg {
        display: none;
    }

    .product {
        vertical-align: bottom;
    }
</style>
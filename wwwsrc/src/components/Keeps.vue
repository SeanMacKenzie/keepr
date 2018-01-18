<template>
    <div class="row keeps">
        <div class="screentitle">
            <h1>Available Keeps</h1>

        </div>
        <div class="col-md-4 border" v-for="(keep, i) in keeps">
            <div class="keepview">

                <div class="keepuser-view" v-if="user.username != null">

                    <button class="keep-title" type="button" data-toggle="modal" @click="getKeep(keep.id); getUserVaults();" data-target="#selectedKeep">
                        <h4>
                            <b>{{keep.name}}</b>
                        </h4>
                    </button>
                </div>
                <div class="keep-view" v-else>
                    <button class="keep-title" type="button" data-toggle="modal" data-target="#loginKeepModal">
                        <h4>
                            <b>{{keep.name}}</b>
                        </h4>
                    </button>

                </div>
                <h5>
                    <b>{{keep.description}}</b>
                </h5>
                <div class="on-hover-things">
                    <img :src="keep.image" width="150" height="150" class="keepimage">
                    <div class="middle">
                        <div class="buttonstuff">
                            <button class="btn btn-success btn-md">Share</button>
                            <button class="btn btn-primary btn-md" type="button" data-toggle="modal" @click="getKeep(keep.id); getUserVaults();" data-target="#selectedKeep">View</button>
                            <button class="btn btn-danger btn-md" type="button" data-toggle="modal" @click="getKeep(keep.id); getUserVaults();" data-target="#selectedKeep">Keep in vault</button>
                        </div>
                    </div>

                </div>
                <h5>Has been in {{keep.shares}} vaults</h5>
            </div>
        </div>
        <div class="modal fade" id="loginKeepModal" tabindex="-1" role="dialog" aria-labelledby="loginKeepModalLabel">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h4 class="modal-title" id="loginKeepModal">Please Login to Continue</h4>
                    </div>
                    <div class="modal-body">
                        <form class="form" @submit.prevent="submitKeepLogin">
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
                        <button type="submit" class="btn btn-default btn-success pull-left" data-dismiss="modal" data-target="#loginKeepModal">
                            <span class="glyphicon glyphicon-remove"></span>Cancel</button>
                        <p>Need to register?
                            <button type="button" class="btn btn-default" @click="changeUp">Sign Up</button>
                        </p>
                        <div id="regkeep">
                            <form class="form" @submit.prevent="submitKeepRegister">
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
        <div class="modal fade" id="selectedKeep" tabindex="-1" role="dialog" aria-labelledby="selectedKeepLabel">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h2 class="modal-title" id="keepModal">{{activekeep.name}}</h2>
                        <h6 class="modal-description">{{activekeep.description}}</h6>
                    </div>
                    <div class="modal-body">
                        <img :src="activekeep.image" style="max-width: 100%">
                        <form name="keepmover" class="form" @submit.prevent="moveKeep(); incrementShares(activekeep);">
                            <select class="select" v-model="vaultSelection.vaultId">
                                <option disabled selected value="">Select Vault</option>
                                <option v-for="vault in vaults" :value="vault.id">{{vault.name}}</option>
                            </select>
                            <button type="submit">Put in vault</button>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <h5>This is where we add to vault or share of something like that</h5>
                    </div>
                </div>
            </div>
        </div>
    </div>


</template>

<script>
    export default {
        name: 'Keeps',
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
                vaultSelection: {
                    vaultId: '',
                    keepId: '',
                    userId: ''
                }
            }

        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            },
            user() {
                return this.$store.state.user


            },
            activekeep() {
                return this.$store.state.activekeep
            },
            vaults() {
                return this.$store.state.vaults
            }

        },
        mounted() {
            this.$store.dispatch('getKeeps')
            this.$store.dispatch('getUserVaults', this.user.id)
        },


        methods: {

            getKeep(id) {
                this.$store.dispatch('getKeep', id)
            },
            submitKeepLogin() {
                this.$store.dispatch('submitKeepLogin', this.login)
                this.login = {
                    email: '',
                    password: ''
                }
            },
            submitKeepRegister() {
                this.$store.dispatch('submitKeepRegister', this.register)
                this.register = {
                    username: '',
                    email: '',
                    password: ''
                }
            },
            changeUp() {
                var x = document.getElementById('regkeep');
                if (x.style.display === 'block') {
                    x.style.display = 'none';
                } else {
                    x.style.display = 'block';
                }
            },
            moveKeep() {
                this.vaultSelection.keepId = this.activekeep.id
                this.vaultSelection.userId = this.user.id
                this.$store.dispatch('addVaultKeep', this.vaultSelection)
                this.vaultSelection = {
                    vaultId: '',
                    keepId: '',
                    userId: ''
                }
            },
            getUserVaults() {
                this.$store.dispatch('getUserVaults', this.user.id)
            },
            incrementShares(activekeep) {
                activekeep.shares++
                this.$store.dispatch('updateKeep', activekeep)


            }
        }
    }

</script>

<style>
    #regkeep {
        display: none;
    }

    .keepimage {
        opacity: 1;
        backface-visibility: hidden;
        transition: .5s ease;
    }

    .middle {
        transition: .5s ease;
        opacity: 0;
        text-align: center;
    }

    .on-hover-things:hover .keepimage {
        opacity: 0.3;
    }

    .on-hover-things:hover .middle {
        opacity: 1;
    }

    .keepview {
        background-color: rgb(218, 216, 216);
        border-width: 5px;
        border-color: black;
        color: black;

    }

    .form {
        font-family: 'Karla', sans-serif;
    }
    .screentitle {
        color: white
    }
</style>
<template>
    <div class="row keeps">
        <h1>Keeps yo!</h1>
        <div class="col-md-4 border" v-for="(keep, i) in keeps">
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
            <h6>{{keep.description}}</h6>
            <img :src="keep.image" width="150" height="150">
            <h6>Has been in {{keep.shares}} vaults</h6>
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
</style>
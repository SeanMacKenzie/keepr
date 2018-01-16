<template>
    <div class="dashboard container-fluid">
        <div class="row banner">
            <div class="col-sm-3 product">
                <h4>keepr</h4>
            </div>
            <div class="col-sm-6 text-center welcome">
                <h2>Welcome {{user.username}}</h2>
            </div>
            <div class="col-sm-3 logout">
                <button type="button" class="btn btn-lg btn-danger" @click="logout">Logout</button>
            </div>
        </div>
        <div class="row intro">
            <h3>Hello {{user.username}}, this is where you can manage you vaults.</h3>
        </div>
        <div class="row new-vault">
            <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#createVaultModal">Create a new Vault</button>
            <div class="modal fade" id="createVaultModal" tabindex="-1" role="dialog" aria-labelledby="createVaultModalLabel">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                            <h4 class="modal-title" id="creatVault">Create Vault</h4>
                        </div>
                        <div class="modal-body">
                            <form class="form" id="vault" @submit.prevent="createVault">
                                <div class="form-group">
                                    <label for="name">Title</label>
                                    <input type="text" class="form-control" name="name" placeholder="Title" v-model='newVault.name' required>
                                </div>
                                <div class="form-group">
                                    <label for="description">Description</label>
                                    <input type="text" class="form-control" name="description" placeholder="Description" v-model='newVault.description'>
                                </div>
                                <div class="form-group">
                                    <button type="submit">Submit</button>
                                </div>
                            </form>
                        </div>
                        <div class="modal-footer">
                            <button type="submit" class="btn btn-default btn-success" data-dismiss="modal" data-target="createVaultModal">
                                <span class="glyphicon glyphicon-remove"></span>Cancel
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Dashboard',
        data() {
            return {
                newVault: {
                    name: '',
                    description: '',
                    userId: ''
                }
            }

        },
        methods: {
            logout() {
                this.$store.dispatch('logout')
            },
            createVault() {
                this.newVault.userId = this.user.id
                this.$store.dispatch('createVault', this.newVault)
                this.newVault = {
                    name: '',
                    description: '',
                    userId: ''
                }
            },


        },
        computed: {
            user() {
                return this.$store.state.user
            }
        }
    }

</script>

<style>
    
</style>
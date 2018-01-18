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
            <h3>Hello {{user.username}}. This is where you can add keeps, manage you vaults, and be awesome.</h3>
        </div>
        <div class="row navigation">
            <div class="col-md-4 add-vault text-center">
                <button type="button" class="btn btn-success btn-lg" data-toggle="modal" data-target="#createVaultModal">Create a new Vault</button>
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
            <div class="col-md-4 back text-center">
                <button class="btn btn-lg btn-success">
                    <router-link :to="'Main'">Back to All Keeps</router-link>
                </button>
            </div>

            <div class="col-md-4 add-keep text-center">
                <button type="button" class="btn btn-success btn-lg" data-toggle="modal" data-target="#createKeepModal">Create a new Keep</button>
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
        <div class="row management">
            <vaults class="col-md-6 vaults"></vaults>
            <userskeeps class="col-md-6 userskeeps"></userskeeps>
        </div>


    </div>
</template>

<script>
    import Vaults from '@/components/Vaults'
    import Userskeeps from '@/components/Userskeeps'
    export default {
        name: 'Dashboard',
        data() {
            return {
                newVault: {
                    name: '',
                    description: '',
                    userId: ''
                },
                newKeep: {
                    name: '',
                    description: '',
                    image: '',
                    shares: '',
                    views: '',
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
            createKeep() {
                this.newKeep.views = 0
                this.newKeep.shares = 0
                this.newKeep.userId = this.user.id
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
            user() {
                return this.$store.state.user
            }
        },
        components: {
            Vaults,
            Userskeeps

        }
    }

</script>

<style>
    .intro {
        color: white;
    }
</style>
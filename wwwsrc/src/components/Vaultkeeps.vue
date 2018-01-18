<template>
    <div class="vaultkeeps container-fluid">
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
        <div class="row title">
            <h2>{{activevault.name}}</h2>
        </div>
        <div class="row description">
            <h2>{{activevault.description}}</h2>
        </div>
        <div class="navigation">
            <div class="col-md-6 main">
                <button class="btn btn-lg btn-success">
                    <router-link :to="'Dashboard'">Back to Dashboard</router-link>
                </button>
            </div>
            <div class="col-md-6 delete">
                <button class="btn btn-lg btn-danger" @click="removeVault(activevault.id)">Delete this Vault</button>
            </div>
        </div>
        <div class="vaultkeeps">
            <h1>Vault keeps yo!</h1>
            <div class="col-md-6 border" v-for="keep in vaultkeeps">
                <button class="keep-title" type="button" data-toggle="modal" @click="getKeep(keep.id)" data-target="#selectedKeep">
                    <h4>
                        <b>{{keep.name}}</b>
                    </h4>

                </button>
                <h6>{{keep.description}}</h6>
                <img :src="keep.image" width="250" height="250">
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
        name: 'Vaultkeeps',
        data() {
            return {

            }
        },
        methods: {
            logout() {
                this.$store.dispatch('logout')
            },
            removeVault() {
                this.$store.dispatch('removeVault', this.activevault.id)
            },
            getKeep(id) {
                this.$store.dispatch('getKeep', id)
            },
            removeFromVault(activevaultkeep) {
                this.store.dispatch('removeVaultKeep', activevaultkeep.id)
            }
        },
        computed: {
            activevault() {
                return this.$store.state.activevault
            },
            user() {
                return this.$store.state.user
            },
            vaultkeeps() {
                return this.$store.state.vaultkeeps
            },
            activevaultkeep() {
                return this.$store.state.activevaultkeep
            },
            activekeep() {
                return this.$store.state.activekeep
            }

        },
        mounted() {

        },

    }
</script>

<style>
</style>
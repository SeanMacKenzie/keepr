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
                // var vaultId = this.activevault.id
                this.$store.dispatch('removeVault', this.activevault.id)
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
            }
        },
        mounted() {

        },

    }
</script>

<style>
</style>
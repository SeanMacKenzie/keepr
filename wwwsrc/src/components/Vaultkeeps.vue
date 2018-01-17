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
            }
        },
        mounted() {
            this.$store.dispatch('getVaultKeeps', this.activeVault.id)
        },
        computed: {
            activeVault() {
                return this.$store.state.activeVault
            },
            user() {
                return this.$store.state.user
            }
        }
    }
</script>

<style>
</style>
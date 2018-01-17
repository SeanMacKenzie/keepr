<template>
    <div class="row vaults text-center">
        <h1>Vaults yo!</h1>
        <div class="col-sm-6" v-for="vault in vaults">
            <router-link class="vault-title" :to="'Vaultkeeps'">
                <h3><span @click="getVault(vault.id)">{{vault.name}}</span></h3>
            </router-link>
            <p>{{vault.description}}</p>
        </div>
    </div>
</template>

<script>
    export default {
        name: "Vaults",
        data() {
            return {

            }
        },
        mounted() {
            this.$store.dispatch('getUserVaults', this.user.id)
        },
        computed: {
            vaults() {
                return this.$store.state.vaults
            },
            activevault() {
                return this.$store.state.activevault
            },
            user() {
                return this.$store.state.user
            }
        },
        methods: {
            getVault(id) {
                this.$store.dispatch('getVault', id)
            }
        }

    }

</script>









<style>
</style>
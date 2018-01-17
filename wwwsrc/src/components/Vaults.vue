<template>
    <div class="row vaults text-center">
        <h1>Vaults yo!</h1>
        <div class="col-sm-6" v-for="vault in vaults">
            <h3>{{vault.name}}</h3>
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
        }
        
    }

</script>

<style>
    
</style>
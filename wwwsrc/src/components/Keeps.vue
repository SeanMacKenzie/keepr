<template>

</template>

<script>
    export default {
        name: 'Keeps',
        data() {
            return {
                
            }

        },
        mounted() {
            this.$store.dispatch('getKeeps')
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            },
            user() {
                return this.$store.state.user
            }

        },
        methods: {
            
            removeKeep() {
                this.$store.dispatch('removeKeep', keep)
            }
        }
    }

</script>

<style>
</style>
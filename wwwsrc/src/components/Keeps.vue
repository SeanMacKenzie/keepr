<template>

</template>

<script>
    export default {
        name: 'Keeps',
        data() {
            return {
                newKeep: {
                    name: '',
                    description: '',
                    image: '',
                    shares: '',
                    userId: ''
                }
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
            createKeep() {
                this.newKeep.userId = this.user._id
                this.$store.dispatch('createKeep', this.newKeep)
                this.newKeep = {
                    name: '',
                    description: '',
                    image: '',
                    shares: '',
                    userId: ''
                }
            },
            removeKeep() {
                this.$store.dispatch('removeKeep', keep)
            }
        }
    }

</script>

<style>
</style>
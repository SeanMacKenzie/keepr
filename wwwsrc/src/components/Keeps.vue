<template>
    <div class="row keeps">
        <h1>Keeps yo!</h1>
        <div class="col-md-4" v-for="(keep, i) in keeps">
            <h4><b>{{keep.name}}</b></h4>
            <h6>{{keep.description}}</h6>
            <img :src="keep.image" width="150" height="150">
        </div>
    </div>

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
            },
            activekeep() {
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
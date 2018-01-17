<template>
    <div class="row keeps">
        <h1>Keeps yo!</h1>
        <div class="col-md-4 border" v-for="(keep, i) in keeps">
            <button class="keep-title" type="button" data-toggle="modal" @click="getKeep(keep.id)" data-target="#selectedKeep">
                <h4>
                    <b>{{keep.name}}</b>
                </h4>
            </button>
            <h6>{{keep.description}}</h6>
            <img :src="keep.image" width="150" height="150">
            <h6>Currently in {{keep.shares}} vaults</h6>
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
                return this.$store.state.activekeep
            }

        },
        methods: {

            getKeep(id) {
                this.$store.dispatch('getKeep', id)
            }
        }
    }

</script>

<style>
</style>
<template>
    <div class="row created-keeps text-center">
        <h1>User keeps yo!</h1>
        <div class="col-12-sm" v-for="keep in keeps">
            <button class="keep-title" type="button" data-toggle="modal" @click="getKeep(keep.id)" data-target="#selectedKeep">
                <h4>
                    <b>{{keep.name}}</b>
                </h4>
            </button>
            <h6>{{keep.description}}</h6>
            <img :src="keep.image" width="150" height="150">
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
        name: "Userkeeps",
        data() {
            return {

            }
        },
        mounted() {
            this.$store.dispatch('getUserKeeps', this.user.id)
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            keeps() {
                return this.$store.state.keeps
            },
            activekeep() {
                return this.$store.state.activekeep
            }
        }
    }

</script>

<style>
</style>
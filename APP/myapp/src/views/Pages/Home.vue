<template>
    <div>
        这是一个新的页面{{Mes}}
    </div>
</template>
<style scoped>

</style>
<script>
export default {
    data(){
        return {
            Mes:"HelloWord"
        }
    },
    methods:{},
    mounted:function(){
        console.log('页面开始吧了');
    }
}
</script>
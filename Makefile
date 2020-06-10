all: build run


## build@编译应用。
.PHONY: build
build:
	@dotnet build


## clean@清理编译、日志和缓存等数据。
.PHONY:clean
clean: 
	@rm -rf ./.vs
	@rm -rf ./.vscode
	@rm -rf ./.DS_Store
	@rm -rf ./deeplink/obj
	@rm -rf ./deeplink/bin


## commit <msg>@Git本地Commit(如:make commit msg="备注内容",msg参数为可选项)。
.PHONY:commit
message:=$(if $(msg),$(msg),"Rebuilded at $$(date '+%Y年%m月%d日 %H时%M分%S秒')");
commit:
	@echo "\033[0;34mPush to remote...\033[0m"
	@git add .
	@git commit -m $(message)
	@echo "\033[0;31mCommit成功\033[0m"


## push <msg>@执行commit并push到远程Git仓库,格式如commit命令。
.PHONY:push
push:commit
	@git push #origin master
	@echo "\033[0;31mPush成功\033[0m"


## run@运行服务。
.PHONY:run
run: 
	@dotnet run -p ./deeplink


## help@查看make帮助。
.PHONY:help
help:Makefile
	@echo "Usage:\n  make [command]"
	@echo
	@echo "Available Commands:"
	@sed -n "s/^##//p" $< | column -t -s '@' |grep --color=auto "^[[:space:]][a-z]\+[[:space:]]"
	@echo
	@echo "For more to see https://makefiletutorial.com/"



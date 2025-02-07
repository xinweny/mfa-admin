from app.api.member.routers import member_router
from app.api.membership.routers import membership_router
from app.api.due.routers import due_router
from app.api.address.routers import address_router
from app.api.exchange.routers import exchange_router
from app.api.board_member.routers import board_member_router

routers = (
    membership_router,
    member_router,
    due_router,
    address_router,
    exchange_router,
    board_member_router,
)
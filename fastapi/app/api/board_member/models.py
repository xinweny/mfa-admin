from datetime import date
from typing import Optional
from uuid import UUID

from sqlalchemy import ForeignKey
from sqlalchemy.orm import Mapped, mapped_column, relationship

from app.database import Base
from app.api.board_member.constants import BoardPosition
from app.api.member.models import Member

class BoardMember(Base):
    __tablename__ = 'board_members'
  
    id: Mapped[UUID] = mapped_column(primary_key=True)
    
    start_date: Mapped[date]
    end_date: Mapped[Optional[date]]
    board_position: Mapped[BoardPosition]
    
    member_id: Mapped[UUID] = mapped_column(ForeignKey('members.id'))
    member: Mapped[Member] = relationship(Member, back_populates='children')